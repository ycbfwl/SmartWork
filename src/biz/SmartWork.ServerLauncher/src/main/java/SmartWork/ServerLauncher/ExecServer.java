package SmartWork.ServerLauncher;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.Hashtable;
import java.util.List;

import com.google.gson.Gson;

@SuppressWarnings("rawtypes")
public class ExecServer {
	public Hashtable para;
	public String Header;
	
	 public	ExecServer(String serverIn)
		{
		 Gson gson = new Gson();
		 ExecServer dbh = gson.fromJson(serverIn, ExecServer.class);
		 this.Header = dbh.Header;
		 this.para  = dbh.para;
		}
	 
	 @SuppressWarnings("unchecked")
	 public String exec()
	 {
		 String returnBackMsg = "";
		 try {
		 String[] splits = Header.split("#");
		 String className = splits[0];
		 String methodName = splits[1];
		 
		 Class cls = Class.forName(className);
		
		Method setMethod = cls.getDeclaredMethod(methodName,Hashtable.class); 
		
		Gson gson = new Gson();
		
		 returnBackMsg = gson.toJson(setMethod.invoke(cls.newInstance(),para), List.class) ;
		
		
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (NoSuchMethodException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (SecurityException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IllegalArgumentException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (InvocationTargetException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (InstantiationException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		  
		 return returnBackMsg;
	 }
}
