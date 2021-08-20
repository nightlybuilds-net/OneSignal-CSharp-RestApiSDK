using System.Threading.Tasks;

namespace OneSignal.CSharp.HttpClient.NetStandard.Resources.Notifications
{
    /// <summary>
    /// Interface used to unify Notification Resource classes.
    /// </summary>
    public interface INotificationsResource
    {
        /// <summary>
        /// Creates a new notification.
        /// </summary>
        /// <param name="options">This parameter can contai variety of possible options used to create notification.</param>
        /// <returns>Returns result of notification create operation.</returns>
        Task<NotificationCreateResult> Create(NotificationCreateOptions options);

        /// <summary>
        /// Cancel notification  Stop a scheduled or currently outgoing notification
        /// </summary>
        /// <param name="options">This parameter contains the information required to cancel a scheduled notification</param>
        /// <returns>Returns result of notification cancel operation.</returns>
        Task<NotificationCancelResult> Cancel(NotificationCancelOptions options);

        /// <summary>
        /// Get report about notification
        /// </summary>
        /// <param name="options">This parameter can contai variety of possible options used to create notification.</param>
        /// <returns>Returns result of notification create operation.</returns>
        Task<NotificationViewResult> View(NotificationViewOptions options);
    }
}
