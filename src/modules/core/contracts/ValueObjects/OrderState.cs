namespace MagCoders.Orders.Modules.Core.Contracts.ValueObjects;

/// <summary>
/// Representation of order state.
/// </summary>
/// <param name="Code">State code.</param>
/// <param name="Name">State name.</param>
public record struct OrderState(int Code, string Name)
{
	/// <summary>
	/// Initializes new instance of <see cref="OrderState"/> based on provided code value.
	/// </summary>
	/// <param name="value">Order state code value.</param>
	/// <returns>Representation of Order state based on value.</returns>
	/// <exception cref="NotSupportedException">Throws not supported exception when state is not defined.</exception>
	public static OrderState Create(int value)
	{
		var state = OrderStates.All.FirstOrDefault(x => x.Code == value);
		if (state == default)
		{
			throw new NotSupportedException($"State with code {value} is not supported yet.");
		}

		return state;
	}
}

/// <summary>
/// Static class to wrap possible values of order states.
/// </summary>
public static class OrderStates
{
	/// <summary>
	/// Order was archived. It's not visible in active orders.
	/// </summary>
	public static readonly OrderState Archived = new OrderState(10, "Archived");

	/// <summary>
	/// Order was cancelled. For example due to unpaid payment.
	/// </summary>
	public static readonly OrderState Cancelled = new OrderState(11, "Cancelled");

	/// <summary>
	/// Order was delivered but customer complained about product.
	/// </summary>
	public static readonly OrderState Complained = new OrderState(12, "Complained");

	/// <summary>
	/// Order is confirmed.
	/// </summary>
	public static readonly OrderState Confirmed = new OrderState(3, "Confirmed");

	/// <summary>
	/// Order is delivered. Confirmation come from courier.
	/// </summary>
	public static readonly OrderState Delivered = new OrderState(9, "Delivered");

	/// <summary>
	/// Order delivery is in progress. Package was passed to courier.
	/// </summary>
	public static readonly OrderState DeliveryPending = new OrderState(8, "DeliveryPending");

	/// <summary>
	/// Order is draft. It's representation of cart.
	/// </summary>
	public static readonly OrderState Draft = new OrderState(2, "Draft");

	/// <summary>
	/// Order is new.
	/// </summary>
	public static readonly OrderState New = new OrderState(1, "New");

	/// <summary>
	/// System received confirmation about receiving payment.
	/// </summary>
	public static readonly OrderState Paid = new OrderState(5, "Paid");

	/// <summary>
	/// Payment process was started but failed.
	/// </summary>
	public static readonly OrderState PaymentFailed = new OrderState(13, "PaymentFailed");

	/// <summary>
	/// Order was confirmed and payment process is in progress.
	/// </summary>
	public static readonly OrderState PaymentPending = new OrderState(4, "PaymentPending");

	/// <summary>
	/// Order is prepared and ready for delivery.
	/// </summary>
	public static readonly OrderState ReadyForDelivery = new OrderState(7, "ReadyForDelivery");

	/// <summary>
	/// Order is ready to be prepared.
	/// </summary>
	public static readonly OrderState ReadyForFulfillment = new OrderState(6, "ReadyForFulfillment");

	/// <summary>
	/// Order is new.
	/// </summary>
	public static readonly OrderState SoftDeleted = new OrderState(-1, "Removed");

	/// <summary>
	/// Representation of all possible states.
	/// </summary>
	public static readonly OrderState[] All =
	[
		Archived,
		Cancelled,
		Complained,
		Confirmed,
		Delivered,
		DeliveryPending,
		Draft,
		New,
		Paid,
		PaymentFailed,
		PaymentPending,
		ReadyForDelivery,
		ReadyForFulfillment,
		SoftDeleted,
	];
}