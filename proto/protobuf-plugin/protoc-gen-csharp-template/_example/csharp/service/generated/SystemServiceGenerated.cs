using Google.Protobuf;
using System.Collections.Generic;

//GENERATED CODE, DO NOT EDIT !
namespace Test.CsharpNamespace
{
    public partial class SystemService : BaseService
    {
        public static SystemService New()
        {
            return new SystemService();
        }

        public void Ping(OnProtoResponseSuccess<SystemPingResponse> onSuccess, OnProtoResponseFailure onFailure)
        {
            SystemPingRequest request = new SystemPingRequest();
            
            GetProtoResponse<SystemPingResponse>("System/Ping", request, SystemPingResponse.Parser, onSuccess, onFailure);
        }

        public void Signup(string challenge, string response, string adid, Test.CsharpNamespace.Platform platform, string version, uint initialHeroId, OnProtoResponseSuccess<SystemSignupResponse> onSuccess, OnProtoResponseFailure onFailure)
        {
            SystemSignupRequest request = new SystemSignupRequest();
            request.Challenge = challenge;
            request.Response = response;
            request.Adid = adid;
            request.Platform = platform;
            request.Version = version;
            request.InitialHeroId = initialHeroId;
            
            GetProtoResponse<SystemSignupResponse>("System/Signup", request, SystemSignupResponse.Parser, onSuccess, onFailure);
        }

        public void Login(string adid, string gameToken, Test.CsharpNamespace.Platform platform, string version, OnProtoResponseSuccess<SystemLoginResponse> onSuccess, OnProtoResponseFailure onFailure)
        {
            SystemLoginRequest request = new SystemLoginRequest();
            request.Adid = adid;
            request.GameToken = gameToken;
            request.Platform = platform;
            request.Version = version;
            
            GetProtoResponse<SystemLoginResponse>("System/Login", request, SystemLoginResponse.Parser, onSuccess, onFailure);
        }
    }
    
}