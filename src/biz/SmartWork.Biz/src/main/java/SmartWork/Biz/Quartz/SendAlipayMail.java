package SmartWork.Biz.Quartz;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import org.quartz.Job;
import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;

import SmartWork.Common.DBHelper;
import SmartWork.Common.Mail;
import SmartWork.Common.MyLogger;
import SmartWork.Common.Utils;


public class SendAlipayMail implements Job {
	private String DrawBodyHtml(String userid) {
		String todayTime = new SimpleDateFormat("yyyyMM").format(new Date());
		HashMap<String,Object> hmArgs = new HashMap<String,Object>();
		hmArgs.put("ARG_USERID", userid);
		
		
		StringBuilder sb = new StringBuilder();
		
		sb.append("【" + userid + "】");
		
		
		ArrayList<String> columnList1 = new ArrayList<String>();
		columnList1.add("MM");
		columnList1.add("MYCOST");

		List<Object> list1 = null;
		try {
			list1 = DBHelper.getList("SELECT_COST_LIST_MM",hmArgs);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		sb.append(Utils.listToHtmlTable(list1, columnList1));

		sb.append("--------------------------------");

		sb.append("<br/>");
		sb.append("<br/>");
		sb.append("<br/>");
		sb.append("<br/>");

		sb.append("List：" + todayTime);

		ArrayList<String> columnList2 = new ArrayList<String>();
		columnList2.add("CREATE_TM");
		columnList2.add("PAY_TO");
		columnList2.add("GOODS_NAME");
		columnList2.add("COST");
		columnList2.add("IN_OUT");
		columnList2.add("PAY_STATUS");
		columnList2.add("REMARK");

		hmArgs.put("ARG_FROM", todayTime);
		List<Object> list2 = null;
		try {
			list2 = DBHelper.getList("SELECT_COST_LIST", hmArgs);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		sb.append(Utils.listToHtmlTable(list2, columnList2));

		return sb.toString();
	}
	
	@SuppressWarnings({ "unchecked", "unused" })
	private String getReciver(String userid)
	{
		HashMap<String,Object> hmArgs = new HashMap<String,Object>();
		hmArgs.put("ARG_USERID", userid);
		String res = "ycbfwl@aliyun.com";
		List<Object> list1 = null;

			try {
				list1 = DBHelper.getList("ALIPAYMAIL.SELECT_RECEIVER",hmArgs);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			for(int i = 0 ; i <list1.size() ; i++ )
			{
				HashMap<String,Object> hmRows = (HashMap<String,Object>)list1.get(i);
				res +=("," +  hmRows.get("MAIL"));
			}
			
			return res;
		
	}
	
	@SuppressWarnings("unused")
	private List<Object> getUser()
	{
		List<Object> userList = new ArrayList<Object>();

			try {
				userList = DBHelper.getList("ALIPAYMAIL.SELECT_USERS");
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		
			return userList;
		
	}

	@SuppressWarnings("unchecked")
	public void execute(JobExecutionContext jobExecutionContext) throws JobExecutionException {

		List<Object> userList =getUser();
		Mail mail = new Mail();
		
		for(int i = 0 ; i < userList.size() ; i++)
		{
			
			HashMap<String,Object> hmRows =  (HashMap<String,Object>)userList.get(i);
			String userid  = hmRows.get("USER_ID").toString();
			
			try {
				mail.sendMail("ycbfwl@aliyun.com,ycbfwl@163.com", "我的账单", DrawBodyHtml(userid));
				MyLogger.debug("SendMail success!!!");
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
		}
		
		
		



	}
}
