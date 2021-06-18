// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Theater.Grpc.Client.User {
  public static partial class User
  {
    static readonly string __ServiceName = "Theater.Grpc.User.User";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Theater.Grpc.Client.User.GetUserByUserNameRequest> __Marshaller_Theater_Grpc_User_GetUserByUserNameRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Theater.Grpc.Client.User.GetUserByUserNameRequest.Parser));
    static readonly grpc::Marshaller<global::Theater.Grpc.Client.User.UserReply> __Marshaller_Theater_Grpc_User_UserReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Theater.Grpc.Client.User.UserReply.Parser));
    static readonly grpc::Marshaller<global::Theater.Grpc.Client.User.GetAllUsersRequest> __Marshaller_Theater_Grpc_User_GetAllUsersRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Theater.Grpc.Client.User.GetAllUsersRequest.Parser));

    static readonly grpc::Method<global::Theater.Grpc.Client.User.GetUserByUserNameRequest, global::Theater.Grpc.Client.User.UserReply> __Method_GetUserByUserName = new grpc::Method<global::Theater.Grpc.Client.User.GetUserByUserNameRequest, global::Theater.Grpc.Client.User.UserReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUserByUserName",
        __Marshaller_Theater_Grpc_User_GetUserByUserNameRequest,
        __Marshaller_Theater_Grpc_User_UserReply);

    static readonly grpc::Method<global::Theater.Grpc.Client.User.GetAllUsersRequest, global::Theater.Grpc.Client.User.UserReply> __Method_GetAllUsers = new grpc::Method<global::Theater.Grpc.Client.User.GetAllUsersRequest, global::Theater.Grpc.Client.User.UserReply>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAllUsers",
        __Marshaller_Theater_Grpc_User_GetAllUsersRequest,
        __Marshaller_Theater_Grpc_User_UserReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Theater.Grpc.Client.User.UserReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for User</summary>
    public partial class UserClient : grpc::ClientBase<UserClient>
    {
      /// <summary>Creates a new client for User</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public UserClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for User that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public UserClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected UserClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected UserClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Theater.Grpc.Client.User.UserReply GetUserByUserName(global::Theater.Grpc.Client.User.GetUserByUserNameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetUserByUserName(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Theater.Grpc.Client.User.UserReply GetUserByUserName(global::Theater.Grpc.Client.User.GetUserByUserNameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetUserByUserName, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Theater.Grpc.Client.User.UserReply> GetUserByUserNameAsync(global::Theater.Grpc.Client.User.GetUserByUserNameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetUserByUserNameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Theater.Grpc.Client.User.UserReply> GetUserByUserNameAsync(global::Theater.Grpc.Client.User.GetUserByUserNameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetUserByUserName, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::Theater.Grpc.Client.User.UserReply> GetAllUsers(global::Theater.Grpc.Client.User.GetAllUsersRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllUsers(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Theater.Grpc.Client.User.UserReply> GetAllUsers(global::Theater.Grpc.Client.User.GetAllUsersRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetAllUsers, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override UserClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new UserClient(configuration);
      }
    }

  }
}
#endregion
