using Microsoft.AspNetCore.Components;

namespace AcademicEnrollment.Services
{
    public class SidebarService
    {
        public bool IsOpen { get; private set; } = true;
        
        public event Action? OnChange;

        public void Toggle()
        {
            IsOpen = !IsOpen;
            NotifyStateChanged();
        }

        public void Open()
        {
            IsOpen = true;
            NotifyStateChanged();
        }

        public void Close()
        {
            IsOpen = false;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
