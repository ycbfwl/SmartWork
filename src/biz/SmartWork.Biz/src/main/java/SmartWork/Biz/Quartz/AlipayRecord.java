package SmartWork.Biz.Quartz;

import java.io.File;
import java.io.IOException;
import java.util.HashMap;
import java.util.List;

import org.apache.log4j.Logger;
import org.quartz.Job;
import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;

import SmartWork.Biz.MyScheduler;
import SmartWork.Common.DBHelper;
import SmartWork.Common.FileCSV;
import SmartWork.Common.FileList;
import SmartWork.Common.MyLogger;
import SmartWork.Common.Utils;



public class AlipayRecord implements Job {

	private static Logger logger = Logger.getLogger(MyScheduler.class);

	public void execute(JobExecutionContext jobExecutionContext) throws JobExecutionException {
		List<String> list = FileList.getFileList(Utils.getPropertie("csvpath"), ".CSV");

		MyLogger.debug("待处理csv数：" + list.size());

		for (int i = 0; i < list.size(); i++) {
			try {
				Object[][] data = FileCSV.getCSVData(list.get(i));

				boolean res = saveAlipayRecord(data);

				if (res) {
					File txtFile = new File(list.get(i));
					txtFile.renameTo(new File(list.get(i) + "_bk"));
					MyLogger.debug(list.get(i) + "---------------------->" + list.get(i) + "_bk");
				}

			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}

	private boolean saveAlipayRecord(Object[][] alipayData) {

		int target = 0;
		int plan = 0;
		String owner = "";
		for (int i = 0; i < alipayData.length; i++) {

			if (alipayData[i].length == 1) {
				String aaa = alipayData[i][0].toString().trim();
				if (aaa.substring(0, 2).equals("账号")) {
					owner = alipayData[i][0].toString().trim().replace("账号:[", "").replace("]", "");
				}

			}
			if (alipayData[i].length < 16 || alipayData[i][0].toString().trim().equals("交易号")) {
				continue;
			}
			plan++;
			HashMap<String, Object> ht = new HashMap<String, Object>();
			ht.put("ARG_EVENT_ID", alipayData[i][0].toString());
			ht.put("ARG_ORDER_NO", alipayData[i][1].toString());
			ht.put("ARG_CREATE_TM", alipayData[i][2].toString());
			ht.put("ARG_PAY_TM", alipayData[i][3].toString());
			ht.put("ARG_UPDATE_TM", alipayData[i][4].toString());
			ht.put("ARG_SOURCE_WAY", alipayData[i][5].toString());
			ht.put("ARG_PAY_TYPE", alipayData[i][6].toString());
			ht.put("ARG_PAY_TO", alipayData[i][7].toString());
			ht.put("ARG_GOODS_NAME", alipayData[i][8].toString());
			ht.put("ARG_COST", alipayData[i][9].toString());
			ht.put("ARG_IN_OUT", alipayData[i][10].toString());
			ht.put("ARG_PAY_STATUS", alipayData[i][11].toString());
			ht.put("ARG_SERVER_COST", alipayData[i][12].toString());
			ht.put("ARG_REJECT", alipayData[i][13].toString());
			ht.put("ARG_REMARK", alipayData[i][14].toString());
			ht.put("ARG_MONEY_STATUS", alipayData[i][15].toString());
			ht.put("ARG_CHECK_STATUS", "N");
			ht.put("ARG_OWNER", owner);
			int l = 0;
			try {
				l = DBHelper.Update("MERGE_RECORD", ht);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			if (l == 1) {
				target++;
				logger.debug("SAVE" + alipayData[i][0].toString() + "Success!");
			} else {
				logger.debug("SAVE" + alipayData[i][0].toString() + "false!");
			}

		}
		MyLogger.debug("应更新：" + plan + "/" + alipayData.length + "条； 实际更新：" + target + "条。");

		if (target != plan) {
			return false;
		}
		return true;
	}

}
