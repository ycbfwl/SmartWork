package SmartWork.Biz;

import java.util.HashMap;
import java.util.List;
import SmartWork.Common.BizBase;
import SmartWork.Common.DBHelper;
import SmartWork.Common.DataAccess.DataSet;

public class Sample extends BizBase {
	public DataSet main(HashMap<String, Object> args) throws Exception
	{
		DataSet dataset= new DataSet();
		List<Object> list1 = DBHelper.getList("ALIPAYMAIL.SAMPLE",args);
		
		this.logger.debug(list1.toString());
		dataset.put("Table1",list1);
		dataset.put("Table2",list1);
		dataset.put("Table3",list1);
		return dataset;
	}
}
