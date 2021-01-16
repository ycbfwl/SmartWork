package SmartWork.ServerLauncher;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.HashMap;

import java.util.LinkedHashMap;
import java.util.regex.Pattern;

import com.google.gson.Gson;

@SuppressWarnings("rawtypes")
public class ExecServer {
	public HashMap args;
	public String header;
	
	 public	ExecServer(String serverIn)
		{
		 Gson gson = new Gson();
		 ExecServer dbh = gson.fromJson(serverIn, ExecServer.class);
		 this.header = dbh.header;
		 this.args  = dbh.args;
		}
	 
	 @SuppressWarnings("unchecked")
	 public String exec()
	 {
		 String returnBackMsg = "";
		 try {
		 String[] splits = header.split("#");
		 String className = splits[0];
		 String methodName = splits[1];
		 
		 Class cls = Class.forName(className);
		
		Method setMethod = cls.getDeclaredMethod(methodName,HashMap.class); 
		
		Gson gson = new Gson();
		
		Object retBacObj = setMethod.invoke(cls.newInstance(),args);
		boolean isMatch = Pattern.matches("^[1-9]\\d*|0$", retBacObj.toString());
		
		if(isMatch)
		{
			returnBackMsg = retBacObj.toString();
		}else
		{
			returnBackMsg = gson.toJson(setMethod.invoke(cls.newInstance(),args), LinkedHashMap.class) ;
		}
		 
		
		
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
