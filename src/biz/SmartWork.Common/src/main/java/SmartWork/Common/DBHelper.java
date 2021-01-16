package SmartWork.Common;

import java.util.HashMap;
import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;

public class DBHelper {
	public static SqlSessionFactory sessionFactory;

	@SuppressWarnings("unchecked")
	public static List<Object> getList(String targetSQL ,  HashMap<String, Object> htArgs) throws Exception {

		SqlSession session = MybatisUtil.getSession();
		List<Object> res = session.selectList(targetSQL,htArgs);
		session.close();
		return res;
	}
	
	public static List<Object> getList(String targetSQL) throws Exception {
		List<Object> res = getList(targetSQL,null);
		return res;
	}
	

	public static int Insert(String targetSQL ,  HashMap<String, Object> htArgs)   {

		int res = 0;
		SqlSession session = MybatisUtil.getSession();
        try{

   		 	res = session.insert(targetSQL,htArgs);
        }
        catch (Exception e){
            MyLogger.debug(e.getMessage());
        }

		session.close();
		session.commit();
		return res;
	}
	

	public static int Delete(String targetSQL ,  HashMap<String, Object> htArgs) throws Exception  {
		
		SqlSession session = MybatisUtil.getSession();
		int res = session.delete(targetSQL,htArgs);
		session.close();
		session.commit();
		return res;
	}
	

	public static int Update(String targetSQL ,  HashMap<String, Object> htArgs)   {
		int res =0;
		SqlSession session = MybatisUtil.getSession();
		
		try{
			res = session.update(targetSQL,htArgs);
		 }
        catch (Exception e){
            MyLogger.debug(e.getMessage());
        }
		
		session.commit();
		session.close();
		return res;
	}
	
}
