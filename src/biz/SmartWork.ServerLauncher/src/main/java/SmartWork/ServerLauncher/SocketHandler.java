package SmartWork.ServerLauncher;

import java.net.InetAddress;
import java.util.Date;


import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.SimpleChannelInboundHandler;

public class SocketHandler extends SimpleChannelInboundHandler<Object>{


	//客户端与服务端创建连接的时候调用
	@Override
	public void channelActive(ChannelHandlerContext ctx) throws Exception {
		NettyConfig.group.add(ctx.channel());
		System.out.println("客户端与服务端连接开启...(socket)");
		System.out.println("连接的客户端地址:" + ctx.channel().remoteAddress());
        System.out.println("连接的客户端ID:" + ctx.channel().id());
        String msg = "client"+ InetAddress.getLocalHost().getHostName() + "success connected！ \n\r";
        ctx.writeAndFlush(msg);
        System.out.println("connection");
        
	}

	//客户端与服务端断开连接的时候调用
	@Override
	public void channelInactive(ChannelHandlerContext ctx) throws Exception {
		NettyConfig.group.remove(ctx.channel());
		System.out.println("客户端与服务端连接关闭...");
	}

	//服务端接收客户端发送过来的数据结束之后调用
	@Override
	public void channelReadComplete(ChannelHandlerContext ctx) throws Exception {
			ctx.flush();
	}

	//工程出现异常的时候调用
	@Override
	public void exceptionCaught(ChannelHandlerContext ctx, Throwable cause) throws Exception {
		cause.printStackTrace();
		ctx.close();
	}

	
	//收到数据时调用
    @Override
    public  void channelRead(ChannelHandlerContext ctx, Object  msg) throws Exception {
        try {
            ByteBuf in = (ByteBuf)msg;
            int readableBytes = in.readableBytes();
            byte[] bytes =new byte[readableBytes];
            in.readBytes(bytes);
            
            String strSocketIn =  new String(bytes);
            System.out.println(strSocketIn);
            System.out.println("服务端接受的消息 : " + msg);
            ExecServer execServer = new ExecServer(strSocketIn);
            		
            //System.out.print(in.toString(CharsetUtil.UTF_8));

           
            
          //返回给客户端的数据，告诉我已经读到你的数据了
            String result = execServer.exec();
            ByteBuf buf = Unpooled.buffer();
            buf.writeBytes(result.getBytes());
            ctx.channel().writeAndFlush(buf);
            
            

        }finally {
            // 抛弃收到的数据
            //ReferenceCountUtil.release(msg);
        }
        
    }
	
	//服务端处理客户端websocket请求的核心方法
	@Override
	protected void messageReceived(ChannelHandlerContext context, Object msg) throws Exception {
		
			handWebsocketFrame(context, (ByteBuf)msg);
		
	}
	
	/**
	 * 处理客户端与服务端之前的websocket业务
	 * 
	 * @param ctx
	 * @param frame
	 */
	private void handWebsocketFrame(ChannelHandlerContext ctx, ByteBuf frame) {

		// 返回应答消息
		// 获取客户端向服务端发送的消息
		String request = ((ByteBuf) frame).toString();
		System.out.println("服务端收到客户端的消息====>>>" + request + "new");
		String tws = new String(new Date().toString() + ctx.channel().id() + " ===>>> " + request);
		// 群发，服务端向每个连接上来的客户端群发消息
		ctx.writeAndFlush(tws);
		NettyConfig.group.writeAndFlush(tws);
	}
	
	


}
