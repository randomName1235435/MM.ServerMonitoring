﻿using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Repository.EntityFramework.ModelConfiguration;

public static class DefaultTargetTypConfiguration
{
    private static readonly Action<ModelBuilder> configuration = modelBuilder =>
    {
        modelBuilder.AddId<TargetTyp>();
        modelBuilder.AddName<TargetTyp>();
        modelBuilder.AddDescription<TargetTyp>();
    };

    public static Action<ModelBuilder> Get()
    {
        return configuration;
    }
}