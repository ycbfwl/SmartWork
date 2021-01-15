package SmartWork.ServerLauncher;

import io.netty.channel.ChannelInitializer;
import io.netty.channel.socket.SocketChannel;

public class SocketChannelHandler extends ChannelInitializer<SocketChannel> {

	@Override
	protected void initChannel(SocketChannel e) throws Exception {
		//e.pipeline().addLast(new DelimiterBasedFrameDecoder(Integer.MAX_VALUE, Delimiters.lineDelimiter()[0]));
		 e.pipeline().addLast(new SocketHandler());
	}

}
