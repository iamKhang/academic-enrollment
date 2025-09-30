using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AcademicEnrollment.Services;

public sealed class TailwindDevServerHostedService : IHostedService, IDisposable
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<TailwindDevServerHostedService> _logger;
    private Process? _tailwindProcess;

    public TailwindDevServerHostedService(IWebHostEnvironment environment, ILogger<TailwindDevServerHostedService> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        if (!_environment.IsDevelopment())
        {
            return Task.CompletedTask;
        }

        var startInfo = new ProcessStartInfo
        {
            FileName = "npm",
            Arguments = "run tailwind:watch",
            WorkingDirectory = _environment.ContentRootPath,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            _tailwindProcess = new Process { StartInfo = startInfo, EnableRaisingEvents = true };
            _tailwindProcess.OutputDataReceived += (_, args) =>
            {
                if (!string.IsNullOrWhiteSpace(args.Data))
                {
                    _logger.LogInformation("[tailwind] {Output}", args.Data);
                }
            };
            _tailwindProcess.ErrorDataReceived += (_, args) =>
            {
                if (!string.IsNullOrWhiteSpace(args.Data))
                {
                    _logger.LogWarning("[tailwind] {Output}", args.Data);
                }
            };

            _tailwindProcess.Start();
            _tailwindProcess.BeginOutputReadLine();
            _tailwindProcess.BeginErrorReadLine();

            _logger.LogInformation("Tailwind watch started.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to start Tailwind watch process. Ensure npm and tailwindcss are installed.");
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        if (_tailwindProcess is { HasExited: false })
        {
            try
            {
                _tailwindProcess.Kill(entireProcessTree: true);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to stop Tailwind watch process cleanly.");
            }
        }

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _tailwindProcess?.Dispose();
    }
}
