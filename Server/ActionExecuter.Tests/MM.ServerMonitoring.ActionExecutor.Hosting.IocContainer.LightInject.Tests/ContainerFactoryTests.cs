using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MM.ServerMonitoring.ActionExecutor.IocContainer.LightInject.Tests;

[TestClass]
public class ContainerFactoryTests
{
    [TestMethod]
    public void Create_ShouldReturnContainerInstance()
    {
        var instance = ContainerFactory.Create();
        Assert.IsNotNull(instance);
    }
}