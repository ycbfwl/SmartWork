package SmartWork.ServerLauncher;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class JavaServer {
  private static DateFormat dateFormat = new SimpleDateFormat("dd/MM/yy hh:mm:ss.SS");
  
  private static void println(String str) {
    System.out.println(str);
    System.out.flush();
  }
  
  private static String timestamp() {
    return dateFormat.format(new Date());
  }
  
  private static void trace(String str) {
    println(timestamp() + " " + str);
  }
  
  public static void main(String[] args) {
    
    if (args.length == 0) {
    	serviceStart(args);
    } else if ("start".equalsIgnoreCase(args[0])) {
      println("Start parameter specified");
      serviceStart(args);
    } else if ("stop".equalsIgnoreCase(args[0])) {
      println("Stop parameter specified");
      serviceStop(args);
    } else {
      println("Command-line parameter '" + args[0] + "' not recognised, doing nothing");
    } 
    
  }
  
  public static void outputJvmDetails() {
    println("JVM " + System.getProperty("java.vm.vendor", "{vm.vendor}") + " " + System.getProperty("java.vm.name", "{vm.name}") + " " + System.getProperty("java.vm.version", "{vm version}"));
  }
  
  public static void outputHeapDetails() {
    Runtime rt = Runtime.getRuntime();
    long totalBytes = rt.totalMemory();
    long freeBytes = rt.freeMemory();
    rt = null;
    trace("Heap Size " + kBytes(totalBytes) + " total, free " + kBytes(freeBytes) + " (used " + kBytes(totalBytes - freeBytes) + ")");
  }
  
  private static String kBytes(long bytes) {
    if (bytes > 1024L)
      bytes -= bytes % 1024L; 
    long kb = bytes / 1024L;
    return Long.toString(kb) + "KB";
  }
  
  public static void serviceStart(String[] args) {
    trace("Service start function invoked...");
    SocketMain.start(args);
  }
  
  public static void serviceStop(String[] args) {
    trace("Service stop function invoked...");
   
    
  }
  
  private static JavaServer serviceInstance = null;
  
  static synchronized JavaServer getServiceInstance() {
    if (serviceInstance == null) {
      trace("Creating singleton instance of SampleService object");
      serviceInstance = new JavaServer();
    } 
    return serviceInstance;
  }
  
  private boolean serviceExecuting = false;
  
  private JavaServer() {
    setServiceExecuting(false);
  }
  
  private synchronized void setServiceExecuting(boolean executingNow) {
    this.serviceExecuting = executingNow;
  }
  
  synchronized boolean isServiceExecuting() {
    return this.serviceExecuting;
  }
}
