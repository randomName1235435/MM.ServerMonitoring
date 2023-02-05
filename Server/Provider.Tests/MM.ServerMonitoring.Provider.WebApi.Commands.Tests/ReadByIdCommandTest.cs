using MM.ServerMonitoring.Provider.WebApi.Commands.Crud;
using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Moq;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Tests;

[TestClass]
public class ReadByIdCommandTest
{
    private readonly CancellationToken cancellationToken = CancellationToken.None;
    private readonly Guid guid = Guid.NewGuid();
    private Mock<ICrudServiceAsync<MonitorActionExecution>> crudServiceMock;

    [TestInitialize]
    public void Initialize()
    {
        this.crudServiceMock = new Mock<ICrudServiceAsync<MonitorActionExecution>>();
    }

    private ReadByIdCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>> CreateInstance()
    {
        return new ReadByIdCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>>(
            this.crudServiceMock.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Ctor_NullParam_ShouldThrow()
    {
        var instance = new ReadByIdCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>>(null);
    }

    private async Task<MonitorActionExecution> CreateAndExecuteAsync(Guid guid)
    {
        var instance = this.CreateInstance();
        return await instance.ExecuteAsync(guid, this.cancellationToken);
    }

    private MonitorActionExecution CreateAndExecute(Guid guid)
    {
        var instance = this.CreateInstance();
        return instance.Execute(guid);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Execute_EmptyId_ShouldThrow()
    {
        this.CreateAndExecute(Guid.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public async Task ExecuteAsync_EmptyId_ShouldThrow()
    {
        await this.CreateAndExecuteAsync(Guid.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(ItemNotFoundException))]
    public void Execute_NonExistingItem_ShouldThrow()
    {
        this.SetupFindById();
        this.CreateAndExecute(this.guid);
    }

    [TestMethod]
    [ExpectedException(typeof(ItemNotFoundException))]
    public async Task ExecuteAsync_NonExistingItem_ShouldThrow()
    {
        this.SetupFindById();
        await this.CreateAndExecuteAsync(this.guid);
    }

    private void SetupFindById(MonitorActionExecution item = null)
    {
        this.crudServiceMock.Setup(m => m.FindById(It.IsAny<Guid>())).Returns(item);
        this.crudServiceMock.Setup(m => m.FindByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(item);
    }

    [TestMethod]
    public void Execute_ValidParam_ShouldSucceed()
    {
        var item = new MonitorActionExecution();
        this.SetupFindById(item);
        var result = this.CreateAndExecute(this.guid);
        Assert.AreEqual(result, item);
    }

    [TestMethod]
    public async Task ExecuteAsync_ValidParam_ShouldSucceed()
    {
        var item = new MonitorActionExecution();
        this.SetupFindById(item);
        var result = await this.CreateAndExecuteAsync(this.guid);
        Assert.AreEqual(result, item);
    }
}