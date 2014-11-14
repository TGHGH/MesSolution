using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IModelFormService))]
	public class ModelFormService : ModelService ,IModelFormService
	{

	}
}
