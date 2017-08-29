<? php


namespace QBNK\QBank\API\Exception;


class RequestException extends QBankApiException
{
    /**
     * @var array
     */
    protected $details = null;

    /**
     * @return array
     */
    public function getDetails()
    {
        return $this->details;
    }

    /**
     * @param array $details
     * @return RequestException
     */
    public function setDetails(array $details)
    {
        $this->details = $details;
        return $this;
    }

    public function __construct($message, $code, \Exception $previous, array $details = null)
    {
        parent::__construct($message, $code, $previous);

        if(!empty($details))
        {
            $this->setDetails($details);
        }
    }
}