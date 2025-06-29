namespace DotNetProjectFile.Analyzers.MsBuild;

/// <summary>Implements <see cref="Rule.OmitXmlDeclarations"/>.</summary>
[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public sealed class OmitXmlDeclarations() : MsBuildProjectFileAnalyzer(Rule.OmitXmlDeclarations)
{
    /// <inheritdoc />
    public override bool DisableOnFailingImport => false;

    /// <inheritdoc />
    protected override void Register(ProjectFileAnalysisContext context)
    {
        if (context.File.Element.Document.Declaration is { })
        {
            context.ReportDiagnostic(Descriptor, context.File.Locations.StartElement);
        }
    }
}
