using Types;

namespace E_Class
{
	// Class that produces Form Factories
	class FormFactoryProducer
	{
		public AbstractFormFactory getFactory(string factoryType)
		{
			switch (factoryType)
			{
				case FormFactoryTypes.USER_FORM:
					return new UserFormFactory();
				default:
					// TODO Display error message
					return null;
			}
		}
	}
}
