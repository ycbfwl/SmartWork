package SmartWork.Common;

import org.apache.log4j.Logger;

public class MyLogger {

	private static Logger logger = null;

	public static void debug(String message) {
		logger = Logger.getLogger(MyLogger.class);

		logger.debug(message);

	}

}
