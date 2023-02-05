using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MM.ServerMonitoring.ActionExecutor.IocContainer.LightInject.Tests;

[TestClass]
public class LightInjectWrapperTests
{
    [TestMethod]
    public void InstanceTest()
    {
        var instance = new LightInjectWrapper();
    }

    [TestMethod]
    public void Register_Type_ShouldNotBeInstanciatedBeforeResolved()
    {
        var instance = new LightInjectWrapper();
        instance.Register<RegisterTypeShouldNotBeInstanciatedBeforeResolvedParam>();

        Assert.IsTrue(RegisterTypeShouldNotBeInstanciatedBeforeResolvedParam.Instances == 0);


        var result = instance.Resolve<RegisterTypeShouldNotBeInstanciatedBeforeResolvedParam>();

        Assert.IsTrue(RegisterTypeShouldNotBeInstanciatedBeforeResolvedParam.Instances == 1);
    }

    private class RegisterTypeShouldNotBeInstanciatedBeforeResolvedParam
    {
        public RegisterTypeShouldNotBeInstanciatedBeforeResolvedParam()
        {
            Instances++;
        }

        internal static int Instances { get; private set; }
    }
}