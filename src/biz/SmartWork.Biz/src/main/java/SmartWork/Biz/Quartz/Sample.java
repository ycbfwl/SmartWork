package SmartWork.Biz.Quartz;

import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;

import SmartWork.Common.BizBase;
import SmartWork.Common.DBHelper;

public class Sample extends BizBase {
	public List<Object> main(Hashtable<?, ?> args)
	{
		//String todayTime = new SimpleDateFormat("yyyyMM").format(new Date());
		HashMap<String,Object> hmArgs = new HashMap<String,Object>();
		hmArgs.put("ARG_USERID", "U0000002");
	
	

	

		List<Object> list1 = null;
		try {
			list1 = DBHelper.getList("SELECT_COST_LIST_MM",hmArgs);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		
		return list1;
	}
}
