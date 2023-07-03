﻿using Microsoft.Extensions.Logging;

using TestProject;

using Xunit.Runner.Devices;
using Xunit.Runner.Devices.VisualRunner;
using Xunit.Runner.Devices.VisualRunner.Maui;
using Xunit.Runner.Devices.XHarness;
using Xunit.Runner.Devices.XHarness.Maui;

namespace SampleMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var runnerOptions = new RunnerOptions
		{
			Assemblies =
			{
				typeof(MauiProgram).Assembly,
				typeof(UnitTest1).Assembly,
			},
		};

		var builder = MauiApp.CreateBuilder();
		builder
			// .UseMauiApp<TestRunnerApp>()
			.UseMauiApp<XHarnessApp>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureXHarness(runnerOptions)
			.ConfigureRunner(runnerOptions);

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
