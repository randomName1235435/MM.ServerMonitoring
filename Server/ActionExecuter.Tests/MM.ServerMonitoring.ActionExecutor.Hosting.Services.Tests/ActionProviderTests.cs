using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;
using Moq;

namespace MM.ServerMonitoring.ActionExecutor.Services.Tests;

[TestClass]
public class ActionProviderTests
{
    private Mock<IAction> actionMock;

    [TestInitialize]
    public void Initialize()
    {
        this.actionMock = new Mock<IAction>();
    }

    [TestMethod]
    public void InstanceTest()
    {
        var instance = new ActionProvider();
    }

    [TestMethod]
    public void Instance_NoParam_ShouldHaveDefaultFactories()
    {
        var instance = new ActionProvider();
        Assert.IsTrue(instance.IsDefaultConfig);
    }

    [TestMethod]
    public void HasAction_NoActions_ShouldFail()
    {
        var actionId = Guid.NewGuid();
        var param = ImmutableDictionary<Guid, Func<ActionConfiguration, IAction>>.Empty;

        var instance = new ActionProvider(param);

        var result = instance.HasAction(new ActionConfiguration { ActionId = actionId });
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void HasAction_ActionParam_ShouldSuccess()
    {
        var actionId = Guid.NewGuid();

        var param = new Dictionary<Guid, Func<ActionConfiguration, IAction>>();
        param.Add(actionId, x => this.actionMock.Object);

        var instance = new ActionProvider(param);

        var result = instance.HasAction(new ActionConfiguration { ActionId = actionId });
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Provide_ActionParam_ShouldReturnRegisteredAction()
    {
        var actionId = Guid.NewGuid();

        var param = new Dictionary<Guid, Func<ActionConfiguration, IAction>>();
        param.Add(actionId, x => this.actionMock.Object);

        var instance = new ActionProvider(param);

        var result = instance.Provide(new ActionConfiguration { ActionId = actionId });
        Assert.AreEqual(result, this.actionMock.Object);
    }

    [TestMethod]
    public void Provide_NoAction_ShouldFail()
    {
        var actionId = Guid.NewGuid();

        var param = ImmutableDictionary<Guid, Func<ActionConfiguration, IAction>>.Empty;

        var instance = new ActionProvider(param);

        var result = instance.Provide(new ActionConfiguration { ActionId = actionId });
        Assert.IsNull(result);
    }
}