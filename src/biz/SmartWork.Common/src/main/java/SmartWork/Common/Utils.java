package SmartWork.Common;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Properties;

public class Utils {

	@SuppressWarnings("unchecked")
	public static String listToHtmlTable(List<Object> list, ArrayList<String> columnList) {
		StringBuilder sb = new StringBuilder();
		sb.append("<table  border=1  cellspacing=0 cellpadding=5 >");
		sb.append("<tr>");
		for (int i = 0; i < columnList.size(); i++) {
			sb.append("<th>" + columnList.get(i).toString() + "</th>");
		}
		sb.append("</tr>");

		for (int j = 0; j < list.size(); j++) {
			HashMap<String, Object> hm = (HashMap<String, Object>) list.get(j);

			sb.append("<tr>");
			for (int i = 0; i < columnList.size(); i++) {
				sb.append("<td>" + hm.get(columnList.get(i).toString()).toString() + "</td>");
			}
			sb.append("</tr>");
		}
		sb.append("</table>");
		return sb.toString();
	}

	public static String getPropertie(String item, String defaultValue) {
		// 使用Class类的getResourceAsStream()方法获取文件 并返回InputStream类的一个对象
		InputStream inputStream = Utils.class.getResourceAsStream("app.properties");
		// 实例化Properties类
		Properties properties = new Properties();
		// 调用load()方法加载properties文件，load里面传入InputSteam类型的参数或者Reader类型的参数
		try {
			properties.load(inputStream);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		// 通过getProperty(String key)方法获取，传入一个String类型的 键，返回一个String类型的值 如果键不存在则返回null
		// 通过getProperty(String key, String
		// defaultValue)方法获取，传入一个String类型的键和一个默认值，返回一个String类型的值 如果键不存在则返回defaultValue
		return properties.getProperty(item, defaultValue);
	}

	public static String getPropertie(String item) {
		String res = null;
		try {
			// 使用Class类的getResourceAsStream()方法获取文件 并返回InputStream类的一个对象
			InputStream inputStream = Utils.class.getClassLoader().getResourceAsStream("app.properties");
			// 实例化Properties类
			Properties properties = new Properties();
			// 调用load()方法加载properties文件，load里面传入InputSteam类型的参数或者Reader类型的参数

			properties.load(inputStream);
			res = properties.getProperty(item, "");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			res = "";
			MyLogger.debug(e.getMessage());
		}
		// 通过getProperty(String key)方法获取，传入一个String类型的 键，返回一个String类型的值 如果键不存在则返回null
		// 通过getProperty(String key, String
		// defaultValue)方法获取，传入一个String类型的键和一个默认值，返回一个String类型的值 如果键不存在则返回defaultValue
		return res;
	}

}
