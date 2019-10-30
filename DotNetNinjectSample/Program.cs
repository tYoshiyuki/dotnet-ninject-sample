using DotNetNinjectSample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace DotNetNinjectSample
{
    class Program
    {
        static void Main()
        {
            // ------------------------------------------------
            // Transientの場合はインスタンスが取得時に毎回再生成される
            // ------------------------------------------------
            var kernel = new StandardKernel();
            kernel.Bind<MainSample>().ToSelf().InTransientScope();
            kernel.Bind<SubSample>().ToSelf().InSingletonScope();

            var sample1 = kernel.Get<MainSample>();
            sample1.Output();

            var sample2 = kernel.Get<MainSample>();
            sample2.Output();
            
            Assert.AreNotEqual(sample1.Id, sample2);
            Assert.AreEqual(sample1.SubSample.Id, sample2.SubSample.Id);


            // ------------------------------------------------
            // Singletonの場合は同一のインスタンスが利用される
            // ------------------------------------------------
            kernel.Dispose();
            kernel = new StandardKernel();
            kernel.Bind<MainSample>().ToSelf().InSingletonScope();
            kernel.Bind<SubSample>().ToSelf().InSingletonScope();

            sample1 = kernel.Get<MainSample>();
            sample1.Output();

            sample2 = kernel.Get<MainSample>();
            sample2.Output();

            Assert.AreEqual(sample1.Id, sample2.Id);
            Assert.AreEqual(sample1.SubSample.Id, sample2.SubSample.Id);


            // ------------------------------------------------
            // SubSampleがDIコンテナに存在しない場合は、引数無しコンストラクタが使われる
            // ------------------------------------------------
            kernel.Dispose();
            kernel = new StandardKernel();
            kernel.Bind<MainSample>().ToSelf().InSingletonScope();

            sample1 = kernel.Get<MainSample>();
            sample1.Output();

            sample2 = kernel.Get<MainSample>();
            sample2.Output();

            Assert.AreEqual(sample1.Id, sample2.Id);
            Assert.IsNull(sample1.SubSample);
            Assert.IsNull(sample2.SubSample);
        }
    }
}
