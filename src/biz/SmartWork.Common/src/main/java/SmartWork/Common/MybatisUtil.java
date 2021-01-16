package SmartWork.Common;


import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;

import java.io.Reader;

public class MybatisUtil {
    public static SqlSessionFactory sessionFactory;
    static {
		try {
			Reader reader = Resources.getResourceAsReader("mybatis.xml");
			sessionFactory = new SqlSessionFactoryBuilder().build(reader);
		} catch (Exception e) {
			MyLogger.debug(e.getMessage());
		}
    }

    public static SqlSession getSession(){
    	
        return sessionFactory.openSession();
    }
}