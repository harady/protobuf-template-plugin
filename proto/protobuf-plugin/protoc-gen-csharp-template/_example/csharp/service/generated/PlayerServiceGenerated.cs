using Google.Protobuf;
using System.Collections.Generic;

//GENERATED CODE, DO NOT EDIT !
namespace Service
{
    public partial class PlayerService : BaseService
    {
        public static PlayerService New()
        {
            return new PlayerService();
        }

        public void Info(Service.SessionData session, Test.CsharpNamespace.PlayerNormalData player, OnProtoResponseSuccess<PlayerInfoResponse> onSuccess, OnProtoResponseFailure onFailure)
        {
            PlayerInfoRequest request = new PlayerInfoRequest();
            request.Session = session;
            request.Player = player;
            
            GetProtoResponse<PlayerInfoResponse>("Player/Info", request, PlayerInfoResponse.Parser, onSuccess, onFailure);
        }
    }
    
}