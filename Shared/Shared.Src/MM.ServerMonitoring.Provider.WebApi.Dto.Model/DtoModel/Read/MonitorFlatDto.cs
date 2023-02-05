﻿using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

public class MonitorFlatDto : IHasId, IHasDescription, IHasName
{
    public string Description { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
}