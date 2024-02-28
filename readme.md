Infrastructure for servermonitoring with independent client, executer and api.

Purpose: Sandbox project for sample implementations

Features:
* Unittestable

Structure:
Client
	Consumer
 
	* WPF
	* ViewComposition with PRISM
	* IOC with Lightinject
	* Simple Logger C#.NET
	* no blocking modal windows
	* validation responsive controls
	* filterable combobox
	* async/await
 
Server
	
	Provider
	* WebApi/Rest
	* async/await
	* validation rules abstractions
	* IOC with ASP.NET
	* DTO mapping
	* mapping with automapper
	* logging with ASP.NET

	ActionExecuter
	* Monitoring configuration from entity framework or json file
	* repository from entity framework or json file
	* Actions
	** Ping
	** HttpRequest
