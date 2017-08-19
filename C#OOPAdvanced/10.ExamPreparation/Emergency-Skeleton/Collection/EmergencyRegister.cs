namespace Emergency_Skeleton.Collection
{
    using Emergency_Skeleton.Models.Emergencies;

    internal class EmergencyRegister
    {
        private const int INITIAL_SIZE = 16;

        private BaseEmergency[] emergencyQueue;

        private int currentSize;

        private int nextIndex;

        public EmergencyRegister()
        {
            this.emergencyQueue = new BaseEmergency[INITIAL_SIZE];
            this.currentSize = 0;
            this.nextIndex = 0;
        }

        private void incrementNextIndex()
        {
            this.nextIndex++;
        }

        private void DecrementNextIndex()
        {
            this.nextIndex--;
        }

        private void IncrementCurrentSize()
        {
            this.currentSize++;
        }

        private void DecrementCurrentSize()
        {
            this.currentSize--;
        }

        private void CheckIfResizeNeeded()
        {
            if (this.currentSize == this.emergencyQueue.Length)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            BaseEmergency[] newArray = new BaseEmergency[2 * this.currentSize];

            for (int i = 0; i < this.currentSize; i++)
            {
                newArray[i] = this.emergencyQueue[i];
            }

            this.emergencyQueue = newArray;
        }

        public void EnqueueEmergency(BaseEmergency emergency)
        {
            this.CheckIfResizeNeeded();

            this.emergencyQueue[this.nextIndex] = emergency;
            this.incrementNextIndex();

            this.IncrementCurrentSize();
        }

        public BaseEmergency DequeueEmergency()
        {
            BaseEmergency removedElement = this.emergencyQueue[0];

            for (int i = 0; i < this.currentSize - 1; i++)
            {
                this.emergencyQueue[i] = this.emergencyQueue[i + 1];
            }

            this.DecrementNextIndex();
            this.DecrementCurrentSize();

            return removedElement;
        }

        public BaseEmergency PeekEmergency()
        {
            BaseEmergency peekedElement = this.emergencyQueue[0];
            return peekedElement;
        }

        public bool IsEmpty()
        {
            return this.currentSize == 0;
        }
    }
}