using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IRouteFormService))]
	public class RouteFormService : RouteService ,IRouteFormService
	{

	}
}
