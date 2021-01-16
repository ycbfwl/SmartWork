package SmartWork.Biz;

import org.quartz.CronScheduleBuilder;
import org.quartz.JobBuilder;
import org.quartz.JobDetail;
import org.quartz.Scheduler;
import org.quartz.SchedulerException;
import org.quartz.SchedulerFactory;
import org.quartz.SimpleScheduleBuilder;
import org.quartz.Trigger;
import org.quartz.TriggerBuilder;
import org.quartz.impl.StdSchedulerFactory;

import SmartWork.Biz.Quartz.AlipayRecord;
import SmartWork.Biz.Quartz.PrintWordsJob;
import SmartWork.Biz.Quartz.SampleJob;
import SmartWork.Biz.Quartz.SendAlipayMail;
import SmartWork.Common.BizBase;

public class MyScheduler extends BizBase {

	public void schedulerRunning() {

		try {
			// 1、创建调度器Scheduler
			SchedulerFactory schedulerFactory = new StdSchedulerFactory();
			Scheduler scheduler;
			scheduler = schedulerFactory.getScheduler();

			// 2、创建JobDetail实例，并与PrintWordsJob类绑定(Job执行内容)
			JobDetail jobDetail = JobBuilder.newJob(PrintWordsJob.class).withIdentity("job1", "group1").build();

			JobDetail jobDetail2 = JobBuilder.newJob(SendAlipayMail.class).withIdentity("job2", "group2").build();

			JobDetail jobDetail3 = JobBuilder.newJob(AlipayRecord.class).withIdentity("AlipayRecord", "group3").build();
			
			JobDetail jobDetail4 = JobBuilder.newJob(SampleJob.class).withIdentity("SampleJob", "group4").build();

			// 3、构建Trigger实例,每隔1s执行一次
			Trigger trigger = TriggerBuilder.newTrigger().withIdentity("trigger1", "triggerGroup1").startNow()
					.withSchedule(
							CronScheduleBuilder.cronSchedule("0 0 6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21 * * ? "))
					.build();

			Trigger trigger2 = TriggerBuilder.newTrigger().withIdentity("trigger2", "triggerGroup2")
					.withSchedule(CronScheduleBuilder.cronSchedule("0 30 7,8,9 * * ?")).build();

			Trigger trigger3 = TriggerBuilder.newTrigger().withIdentity("trigger3", "triggerGroup3").startNow()
					.withSchedule(SimpleScheduleBuilder.simpleSchedule().withIntervalInSeconds(300).repeatForever())
					.build();
			
			Trigger trigger4 = TriggerBuilder.newTrigger().withIdentity("trigger4", "triggerGroup4").startNow()
					.withSchedule(SimpleScheduleBuilder.simpleSchedule().withIntervalInSeconds(60).repeatForever())
					.build();
			
			// 4、执行
			scheduler.scheduleJob(jobDetail, trigger);

			scheduler.scheduleJob(jobDetail2, trigger2);

			scheduler.scheduleJob(jobDetail3, trigger3);
			
			scheduler.scheduleJob(jobDetail4, trigger4);

			this.logger.debug("--------scheduler start ! ------------");

			scheduler.start();

		} catch (SchedulerException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			this.logger.debug(e.getMessage());
		}

	}

}
