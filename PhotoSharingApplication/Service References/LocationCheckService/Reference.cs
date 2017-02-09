﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotoSharingApplication.LocationCheckService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LocationCheckService.ILocationCheckService")]
    public interface ILocationCheckService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationCheckService/GetLocation", ReplyAction="http://tempuri.org/ILocationCheckService/GetLocationResponse")]
        string GetLocation(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocationCheckService/GetLocation", ReplyAction="http://tempuri.org/ILocationCheckService/GetLocationResponse")]
        System.Threading.Tasks.Task<string> GetLocationAsync(string address);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILocationCheckServiceChannel : PhotoSharingApplication.LocationCheckService.ILocationCheckService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LocationCheckServiceClient : System.ServiceModel.ClientBase<PhotoSharingApplication.LocationCheckService.ILocationCheckService>, PhotoSharingApplication.LocationCheckService.ILocationCheckService {
        
        public LocationCheckServiceClient() {
        }
        
        public LocationCheckServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LocationCheckServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LocationCheckServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LocationCheckServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetLocation(string address) {
            return base.Channel.GetLocation(address);
        }
        
        public System.Threading.Tasks.Task<string> GetLocationAsync(string address) {
            return base.Channel.GetLocationAsync(address);
        }
    }
}
