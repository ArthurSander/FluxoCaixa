using FluxoCaixa.Shared.Environments;

namespace FluxoCaixa.Infrastructure.Generic.Files
{
    public static class DirectoryPathProvider
    {
        public static string RelatoriosDirectory =>
            Environment.GetEnvironmentVariable(EnvironmentVariables.RelatoriosDirectory) ??
            GetRootFolder() + "\\relatorios";

        private static string GetRootFolder()
        {
            var directory = new DirectoryInfo(
            Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory.FullName;
        }
    }
}
