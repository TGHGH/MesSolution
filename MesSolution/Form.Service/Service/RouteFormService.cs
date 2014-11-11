using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IRouteFormService))]
	public class RouteFormService : RouteService ,IRouteFormService
	{

	}
}
