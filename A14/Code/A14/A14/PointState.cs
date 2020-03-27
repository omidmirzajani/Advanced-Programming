namespace A14
{
    /// <summary>
    /// این وضعیت نشان دهنده حالتی است که نقطه زده شده
    /// این وضعیت شبیه وضعیت
    /// Accumulate
    /// است
    /// تنها فرقش این است که نقطه جدیدی نمی شود زد.
    /// تغییرات لازم را برای این کار بدهید.
    /// </summary>
    public class PointState : AccumulateState
    {
        public PointState(Calculator calc) : base(calc) { }
        public override IState EnterPoint()
        {
            if (this.Calc.Display == "" || this.Calc.Display == "." || this.Calc.Display == "0.")
                this.Calc.Display = "0.";
            else if (!this.Calc.Display.Contains("."))
                this.Calc.Display += ".";
            return this;
        }
        //#1 لطفا!
    }
}