# GrpcServiceDemo

## gRpcClientDemo
> gRpc客户端

客户端项目文件引用服务
```xml
  <ItemGroup>
    <Protobuf Include="..\Protos\*.proto" GrpcServices="Client" Link="Protos\%(RecursiveDir)%(Filename)%(Extension)" />
  </ItemGroup>
```

## GrpcServiceDemo
> gRpc服务端

服务端项目文件引用服务
```xml
  <ItemGroup>
    <Protobuf Include="..\Protos\*.proto" GrpcServices="Server" Link="Protos\%(RecursiveDir)%(Filename)%(Extension)" />
  </ItemGroup>
```

## Protos
> gRpc服务定义
