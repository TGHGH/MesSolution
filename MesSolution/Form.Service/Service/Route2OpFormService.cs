using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IRoute2OpFormService))]
	public class Route2OpFormService : Route2OpService ,IRoute2OpFormService
	{

	}
}
