using MM.ServerMonitoring.Provider.WebApi.Commands.Crud;
using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;
using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Moq;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Tests;

[TestClass]
public class DeleteByIdCommandTest
{
    private readonly CancellationToken cancellationToken = CancellationToken.None;
    private readonly Guid guid = Guid.NewGuid();
    private Mock<ICrudServiceAsync<MonitorActionExecution>> crudServiceMock;
    private Mock<IDeleteValidator<MonitorActionExecution>> validatioMock;

    [TestInitialize]
    public void Initialize()
    {
        this.validatioMock = new Mock<IDeleteValidator<MonitorActionExecution>>();
        this.crudServiceMock = new Mock<ICrudServiceAsync<MonitorActionExecution>>();
    }

    private DeleteByIdCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>> CreateInstance()
    {
        return new DeleteByIdCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>>(
            this.crudServiceMock.Object, this.validatioMock.Object
        );
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Ctor_NullParam_ShouldThrow()
    {
        var instance =
            new DeleteByIdCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>>(null, null);
    }

    [TestMethod]
    [ExpectedException(typeof(ItemNotFoundException))]
    public void Execute_NonExistingItem_ShouldThrow()
    {
        this.SetupFindById();
        this.CreateAndExecute();
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationFailedException))]
    public void Execute_ValidationFailed_ShouldThrow()
    {
        this.SetupValidationFail();
        this.SetupFindById(new MonitorActionExecution());
        this.CreateAndExecute();
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationFailedException))]
    public async Task ExecuteAsync_ValidationFailed_ShouldThrow()
    {
        this.SetupValidationFail();
        this.SetupFindById(new MonitorActionExecution());
        await this.CreateAndExecuteAsync();
    }

    [TestMethod]
    public async Task ExecuteAsync_ValidParam_ShouldSucceed()
    {
        var calledDelete = false;
        this.SetupValidationSuccess();
        this.SetupFindById(new MonitorActionExecution());
        this.crudServiceMock.Setup(m => m.DeleteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .Callback(() => calledDelete = true);
        await this.CreateAndExecuteAsync();
        Assert.IsTrue(calledDelete);
    }

    [TestMethod]
    [ExpectedException(typeof(ItemNotFoundException))]
    public async Task ExecuteAsync_NonExistingItem_ShouldThrow()
    {
        this.SetupFindById();
        await this.CreateAndExecuteAsync();
    }

    [TestMethod]
    public void Execute_ValidParam_ShouldSucceed()
    {
        var calledDelete = false;
        this.SetupValidationSuccess();
        this.SetupFindById(new MonitorActionExecution());
        this.crudServiceMock.Setup(m => m.Delete(It.IsAny<Guid>())).Callback(() => calledDelete = true);
        this.CreateAndExecute();
        Assert.IsTrue(calledDelete);
    }

    private async Task CreateAndExecuteAsync()
    {
        var instance = this.CreateInstance();
        await instance.ExecuteAsync(this.guid, this.cancellationToken);
    }

    private void CreateAndExecute()
    {
        var instance = this.CreateInstance();
        instance.Execute(this.guid);
    }

    private void SetupValidationSuccess()
    {
        var validationResult = new ValidationResult();
        this.validatioMock.Setup(m => m.Validate(It.IsAny<MonitorActionExecution>())).Returns(() => validationResult);
    }

    private void SetupFindById(MonitorActionExecution item = null)
    {
        this.crudServiceMock.Setup(m => m.FindById(It.IsAny<Guid>())).Returns(item);
        this.crudServiceMock.Setup(m => m.FindByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(item);
    }

    private void SetupValidationFail()
    {
        var validationResult = new ValidationResult();
        validationResult.AddMessage(new ValidationMessage());
        this.validatioMock.Setup(m => m.Validate(It.IsAny<MonitorActionExecution>())).Returns(() => validationResult);
    }
}