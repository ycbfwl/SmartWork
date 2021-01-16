package SmartWork.Common;

import java.io.File;
import java.io.FilenameFilter;
import java.util.ArrayList;
import java.util.List;

public class FileList {
	public static List<String> getFileList(String filterDir, final String filterEndsWith) {
		// 深度遍历的目录
		// filter:过滤器
		// list:容器,存放符合条件的file对象
		FilenameFilter filter = new FilenameFilter() {
			public boolean accept(File dir, String name) {

				return name.toUpperCase().endsWith(filterEndsWith.toUpperCase());
			}
		};
		File dir = new File(filterDir);
		List<String> list = new ArrayList<String>();
		getFiles(dir, filter, list);
		return list;
	}

	private static void getFiles(File dir, FilenameFilter filter, List<String> list) {
		File[] files = dir.listFiles();
		for (File file : files) {
			if (file.isDirectory()) {
				// 如果是目录，则递归
				getFiles(file, filter, list);
			} else {
				// 文件
				// 过滤文件：将符合条件的file对象存储到list集合中
				if (filter.accept(dir, file.getName())) {
					list.add(file.getAbsolutePath());
				}
			}
		}
	}
}
