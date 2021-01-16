package SmartWork.Biz.Quartz;

import org.quartz.Job;
import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;

import SmartWork.Common.BizBase;

public class SampleJob extends BizBase implements Job {

	@Override
	public void execute(JobExecutionContext context) throws JobExecutionException {
		this.logger.debug(this.getClass() + " ==>running");
		
	}

}
