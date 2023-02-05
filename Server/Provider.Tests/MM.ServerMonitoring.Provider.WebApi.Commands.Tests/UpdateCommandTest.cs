using MM.ServerMonitoring.Provider.WebApi.Commands.Crud;
using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;
using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Moq;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Tests;

[TestClass]
public class UpdateCommandTest
{
    private readonly CancellationToken cancellationToken = CancellationToken.None;
    private readonly Guid guid = Guid.NewGuid();
    private Mock<ICrudServiceAsync<MonitorActionExecution>> crudServiceMock;
    private MonitorActionExecution param;
    private Mock<IUpdateValidator<MonitorActionExecution>> validatioMock;

    [TestInitialize]
    public void Initialize()
    {
        this.validatioMock = new Mock<IUpdateValidator<MonitorActionExecution>>();
        this.crudServiceMock = new Mock<ICrudServiceAsync<MonitorActionExecution>>();
        this.param = new MonitorActionExecution();
    }

    private UpdateCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>> CreateInstance()
    {
        return new UpdateCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>>(
            this.crudServiceMock.Object, this.validatioMock.Object
        );
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Ctor_NullParam_ShouldThrow()
    {
        var instance = new UpdateCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>>(null, null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Execute_EmptyId_ShouldThrow()
    {
        this.SetupFindById(new MonitorActionExecution());
        this.CreateAndExecute(this.param);
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationFailedException))]
    public void Execute_ValidationFailed_ShouldThrow()
    {
        this.param.Id = this.guid;
        this.SetupValidationFail();
        this.SetupFindById(new MonitorActionExecution());
        this.CreateAndExecute(this.param);
    }

    [TestMethod]
    public void Execute_ValidParam_ShouldSucceed()
    {
        this.param.Id = this.guid;
        var called = false;
        this.SetupValidationSuccess();
        this.crudServiceMock.Setup(m => m.Update(It.IsAny<MonitorActionExecution>())).Callback(() => called = true);
        this.CreateAndExecute(this.param);
        Assert.IsTrue(called);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public async Task ExecuteAsync_EmptyId_ShouldThrow()
    {
        this.SetupFindById(new MonitorActionExecution());
        await this.CreateAndExecuteAsync(this.param);
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationFailedException))]
    public async Task ExecuteAsync_ValidationFailed_ShouldThrow()
    {
        this.param.Id = this.guid;
        this.SetupValidationFail();
        this.SetupFindById(new MonitorActionExecution());
        await this.CreateAndExecuteAsync(this.param);
    }

    [TestMethod]
    public async Task ExecuteAsync_ValidParam_ShouldSucceed()
    {
        this.param.Id = this.guid;
        var called = false;
        this.SetupValidationSuccess();
        this.crudServiceMock
            .Setup(m => m.UpdateAsync(It.IsAny<MonitorActionExecution>(), It.IsAny<CancellationToken>()))
            .Callback(() => called = true);
        await this.CreateAndExecuteAsync(this.param);
        Assert.IsTrue(called);
    }

    private async Task CreateAndExecuteAsync(MonitorActionExecution item = null)
    {
        var instance = this.CreateInstance();
        await instance.ExecuteAsync(item, this.cancellationToken);
    }

    private void CreateAndExecute(MonitorActionExecution item = null)
    {
        var instance = this.CreateInstance();
        instance.Execute(item);
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