using Microsoft.Extensions.Logging;

namespace OnionCrafter.Base.ServiceContainers.Options
{
    /// <summary>
    ///Implementation of the <see cref="IServiceContainerLoggerOptions"/>.
    ///</summary>
    public class ServiceContainerLoggerOptions : IServiceContainerLoggerOptions
    {
        public ServiceContainerLoggerOptions()
        {
            IncludeServiceNameInMessages = true;
            ReplaceZoneStringWithServiceName = "{ServiceName}";

            SetRemoveServiceSuccessMessage = "{ServiceName} was remove";
            SetRemoveServiceSuccessLogLevel = LogLevel.Information;
            SetRemoveServiceFailureMessage = "{ServiceName} wasn't remove";
            SetRemoveServiceFailureLogLevel = LogLevel.Error;

            SetGetServiceSuccessMessage = "{ServiceName} was obtain";
            SetGetServiceSuccessLogLevel = LogLevel.Information;
            SetGetServiceFailureMessage = "{ServiceName} wasn't obtain";
            SetGetServiceFailureLogLevel = LogLevel.Error;

            SetAddServiceSuccessMessage = "{ServiceName} was create";
            SetAddServiceSuccessLogLevel = LogLevel.Information;
            SetAddServiceFailureMessage = "{ServiceName} wasn't create";
            SetAddServiceFailureLogLevel = LogLevel.Error;

            SetAnyServiceSuccessMessage = "{ServiceName} is registered";
            SetAnyServiceSuccessLogLevel = LogLevel.Information;
            SetAnyServiceFailureMessage = "{ServiceName} isn't registered";
            SetAnyServiceFailureLogLevel = LogLevel.Error;
        }

        /// Gets or sets a value indicating whether to include the service name in log messages.
        /// </summary>
        public bool IncludeServiceNameInMessages { get; set; }

        /// <summary>
        /// Gets or sets the string used to replace the zone placeholder in log messages with the service name.
        /// </summary>
        public string ReplaceZoneStringWithServiceName { get; set; }

        /// <summary>
        /// Gets or sets the log level for the failure message of the "add service" action.
        /// </summary>
        public LogLevel SetAddServiceFailureLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the failure message format for the "add service" action.
        /// </summary>
        public string SetAddServiceFailureMessage { get; set; }

        /// <summary>
        /// Gets or sets the log level for the success message of the "add service" action.
        /// </summary>
        public LogLevel SetAddServiceSuccessLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the success message format for the "add service" action.
        /// </summary>
        public string SetAddServiceSuccessMessage { get; set; }

        public LogLevel SetAnyServiceFailureLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the failure message format for the "any service" action.
        /// </summary>
        public string SetAnyServiceFailureMessage { get; set; }

        /// <summary>
        /// Gets or sets the log level for the success message of the "any service" action.
        /// </summary>
        public LogLevel SetAnyServiceSuccessLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the success message format for the "any service" action.
        /// </summary>
        public string SetAnyServiceSuccessMessage { get; set; }

        /// <summary>
        /// Gets or sets the log level for the failure message of the "get service" action.
        /// </summary>
        public LogLevel SetGetServiceFailureLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the failure message format for the "get service" action.
        /// </summary>
        public string SetGetServiceFailureMessage { get; set; }

        /// <summary>
        /// Gets or sets the log level for the success message of the "get service" action.
        /// </summary>
        public LogLevel SetGetServiceSuccessLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the success message format for the "get service" action.
        /// </summary>
        public string SetGetServiceSuccessMessage { get; set; }

        /// <summary>
        /// Gets or sets the log level for the failure message of the "remove service" action.
        /// </summary>
        public LogLevel SetRemoveServiceFailureLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the failure message format for the "remove service" action.
        /// </summary>
        public string SetRemoveServiceFailureMessage { get; set; }

        /// <summary>
        /// Gets or sets the log level for the success message of the "remove service" action.
        /// </summary>
        public LogLevel SetRemoveServiceSuccessLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the success message format for the "remove service" action.
        /// </summary>
        public string SetRemoveServiceSuccessMessage { get; set; }

        /// <summary>
        /// Gets or sets the log level for the failure message of the "any service" action.
    }
}