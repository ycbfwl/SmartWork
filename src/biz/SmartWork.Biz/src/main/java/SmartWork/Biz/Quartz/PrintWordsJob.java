package SmartWork.Biz.Quartz;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Random;

import org.quartz.Job;
import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;

import SmartWork.Common.Mail;
import SmartWork.Common.MyLogger;



public class PrintWordsJob implements Job {


	public void execute(JobExecutionContext jobExecutionContext) throws JobExecutionException {
		String printTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date());
		String mailBody = "PrintWordsJob start at:" + printTime + ", prints: Hello Job-" + new Random().nextInt(100);
		Mail mail = new Mail();
		try {
			mail.sendMail("ycbfwl@aliyun.com", "我的心跳", mailBody);
			MyLogger.debug(mailBody);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		
	}
}
