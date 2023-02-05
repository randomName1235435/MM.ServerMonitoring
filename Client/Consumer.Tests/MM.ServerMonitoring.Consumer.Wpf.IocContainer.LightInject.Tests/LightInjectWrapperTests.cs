using System.ComponentModel;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using Moq;
using IContainer = MM.ServerMonitoring.Consumer.Wpf.Interface.IContainer;

namespace MM.ServerMonitoring.Consumer.Wpf.IocContainer.LightInject.Tests;

[TestClass]
public class LightInjectWrapperTests
{
    private Mock<ILogger> loggerMock;

    [TestMethod]
    public void InstanceTest()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Resolve_Unregistered_ShouldThrow()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);
        var result = instance.Resolve<LightInjectWrapperTestsParamParamlessCtor>();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Resolve_RegisteredParamlessCtorTypeParam_ShouldbeResolved()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);
        instance.RegisterType<LightInjectWrapperTestsParamParamlessCtor>();
        var result = instance.Resolve<LightInjectWrapperTestsParamParamlessCtor>();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Resolve_RegisteredIContainerCtorParam_ShouldbeResolved()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);
        instance.RegisterType<LightInjectWrapperTestsParamIContainerCtor>();
        var result = instance.Resolve<LightInjectWrapperTestsParamIContainerCtor>();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Resolve_RegisteredParamlessAndIContainerCtorParam_ShouldbeUseIContainerCtor()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);
        instance.RegisterType<LightInjectWrapperTestsParamIContainerCtorAndParameerless>();
        var result = instance.Resolve<LightInjectWrapperTestsParamIContainerCtorAndParameerless>();
        Assert.IsNotNull(result.Container);
    }

    [TestMethod]
    public void Resolve_RegisteredParamlessAndIContainerCtorParam_ShouldContainerParameterShouldBeRoot()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);
        instance.RegisterType<LightInjectWrapperTestsParamIContainerCtorAndParameerless>();
        var result = instance.Resolve<LightInjectWrapperTestsParamIContainerCtorAndParameerless>();
        Assert.AreEqual(result.Container, instance);
    }

    [TestMethod]
    public void Resolve_RegisteredViewViewModel_ShouldResolve()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);

        instance.RegisterView<LightInjectWrapperTestsParamViewMock,
            LightInjectWrapperTestsParamViewModel>();


        var result = instance.Resolve<LightInjectWrapperTestsParamViewMock>();
        Assert.IsNotNull(result.DataContext);
        Assert.IsInstanceOfType(result.DataContext, typeof(LightInjectWrapperTestsParamViewModel));
    }

    [TestMethod]
    public void RegisterResolve_UnRegistered_ShouldBeRegisteredAndResolveD()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);

        var result = instance.RegisterResolve<LightInjectWrapperTestsParamViewMock>();

        Assert.IsNotNull(result);
        Assert.IsTrue(instance.IsRegistered<LightInjectWrapperTestsParamViewMock>());
    }

    [TestMethod]
    public void IsRegistered_Registered_ShouldBeRegistered()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);

        instance.RegisterType<LightInjectWrapperTestsParamViewMock>();

        Assert.IsTrue(instance.IsRegistered<LightInjectWrapperTestsParamViewMock>());
    }

    [TestMethod]
    public void Resolving_RegisteredView_ShouldInstanceViewModelOnce()
    {
        IContainer instance = new LightInjectWrapper(this.loggerMock.Object);

        instance.RegisterView<LightInjectWrapperTestsParamViewMock,
            LightInjectWrapperTestsParamViewModel>();

        var result = instance.Resolve<LightInjectWrapperTestsParamViewMock>();
        Assert.IsTrue(LightInjectWrapperTestsParamViewModel.CreatedInstances == 1);
    }

    [TestInitialize]
    public void Initialize()
    {
        LightInjectWrapperTestsParamViewModel.CreatedInstances = 0;
        this.loggerMock = new Mock<ILogger>();
    }
}