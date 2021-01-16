package SmartWork.Biz;

import java.util.HashMap;
import java.util.List;
import SmartWork.Common.BizBase;
import SmartWork.Common.DBHelper;
import SmartWork.Common.DataAccess.DataSet;

public class bizAlipayChecker extends BizBase {
	
	public DataSet SELECT_DETAIL_MONTH(HashMap<String, Object> args) throws Exception
	{
		DataSet dataset= new DataSet();
		List<Object> list1 = DBHelper.getList("ALIPAYMAIL.SELECT_DETAIL_MONTH",args);
		
		this.logger.debug(list1.toString());
		dataset.put("Table1",list1);

		return dataset;
	}
	
	public int INS_CHECKED_STATUS(HashMap<String, Object> args) throws Exception
	{

		int res = DBHelper.Update("ALIPAYMAIL.INS_CHECKED_STATUS",args);
		this.logger.debug(res);


		return res;
	}
	
	
	public DataSet GET_OWNERS(HashMap<String, Object> args) throws Exception
	{
		DataSet dataset= new DataSet();
		List<Object> list1 = DBHelper.getList("ALIPAYMAIL.GET_OWNERS",args);
		
		this.logger.debug(list1.toString());
		dataset.put("Table1",list1);

		return dataset;
	}
	
}
