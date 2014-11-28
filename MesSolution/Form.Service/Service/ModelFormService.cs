using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IModelFormService))]
	public class ModelFormService : ModelService ,IModelFormService
	{

	}
}
