using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using tvardero.DearDevTools.Components;

namespace tvardero.DearDevTools.Services;

public class MenuManager
{
    private readonly ModImGuiContext _modImGuiContext;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public MenuManager(IServiceProvider serviceProvider, ILogger<MenuManager> logger)
    {
        _serviceProvider = serviceProvider;
        _modImGuiContext = serviceProvider.GetRequiredService<ModImGuiContext>();
        _logger = logger;
    }

    public IReadOnlyList<ImGuiDrawableBase> AllDrawables => _modImGuiContext.RenderList;

    public TDrawable CreateNew<TDrawable>(bool stealFocus = false)
    where TDrawable : ImGuiDrawableBase
    {
        _modImGuiContext.SanitizeRenderList();

        TDrawable? first = _modImGuiContext.RenderList.OfType<TDrawable>().FirstOrDefault();
        if (first is { AllowsMultipleInstances: false }) throw new InvalidOperationException("This drawable type does not allow multiple instances");

        var drawable = ActivatorUtilities.GetServiceOrCreateInstance<TDrawable>(_serviceProvider);
        _modImGuiContext.AddDrawable(drawable);

        if (stealFocus && drawable is ImGuiWindowBase window) window.Focus();

        return drawable;
    }

    public void Destroy<TDrawable>(TDrawable drawable)
    where TDrawable : ImGuiDrawableBase
    {
        _modImGuiContext.RemoveDrawable(drawable);
        drawable.Dispose();
    }

    public void DestroyAllOfType<TDrawable>()
    where TDrawable : ImGuiDrawableBase
    {
        TDrawable[] toDestroy = _modImGuiContext.RenderList.OfType<TDrawable>().ToArray();
        foreach (TDrawable drawable in toDestroy) { Destroy(drawable); }
    }

    public TDrawable EnsureShown<TDrawable>(bool stealFocus = true)
    where TDrawable : ImGuiDrawableBase
    {
        var drawable = GetFirstOrCreateNew<TDrawable>();
        drawable.Show();

        if (stealFocus && drawable is ImGuiWindowBase window) window.Focus();

        return drawable;
    }

    public TDrawable GetFirstOrCreateNew<TDrawable>(bool stealFocus = false)
    where TDrawable : ImGuiDrawableBase
    {
        _modImGuiContext.SanitizeRenderList();

        TDrawable? drawable = _modImGuiContext.RenderList.OfType<TDrawable>().FirstOrDefault();
        if (drawable != null) return drawable;

        _logger.LogInformation("Creating new instance of {DrawableType}", typeof(TDrawable));

        drawable = ActivatorUtilities.GetServiceOrCreateInstance<TDrawable>(_serviceProvider);
        _modImGuiContext.AddDrawable(drawable);

        if (stealFocus && drawable is ImGuiWindowBase window) window.Focus();

        return drawable;
    }

    public void HideAllOfType<TDrawable>()
    where TDrawable : ImGuiDrawableBase
    {
        _modImGuiContext.SanitizeRenderList();

        foreach (TDrawable drawable in _modImGuiContext.RenderList.OfType<TDrawable>()) { drawable.Hide(); }
    }

    public void ShowAllOfType<TDrawable>(bool show = true)
    where TDrawable : ImGuiDrawableBase
    {
        _modImGuiContext.SanitizeRenderList();

        foreach (TDrawable drawable in _modImGuiContext.RenderList.OfType<TDrawable>()) { drawable.Show(show); }
    }
}