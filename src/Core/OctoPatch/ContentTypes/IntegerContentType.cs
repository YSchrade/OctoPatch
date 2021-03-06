﻿namespace OctoPatch.ContentTypes
{
    /// <summary>
    /// Represents a integer based message
    /// </summary>
    public sealed class IntegerContentType : ContentType
    {
        /// <summary>
        /// Optional lowest value for this message
        /// </summary>
        public int? MinimumValue { get; set; }

        /// <summary>
        /// Optional highest value for this message
        /// </summary>
        public int? MaximumValue { get; set; }

        public static IntegerContentType Create(int? minimumValue = null, int? maximumValue = null)
        {
            return new IntegerContentType
            {
                MinimumValue = minimumValue,
                MaximumValue = maximumValue
            };
        }
    }
}
