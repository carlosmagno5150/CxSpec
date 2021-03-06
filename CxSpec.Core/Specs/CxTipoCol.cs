﻿namespace CxSpec.Core.Specs
{
    public enum CxTipoCol
    {
        #region Formats

        //**ID**	**Format Code**
        //0		General
        //1		0
        //2		0.00
        //3		#,##0
        //4		#,##0.00
        //9		0%
        //10	0.00%
        //11	0.00E+00
        //12	# ?/?
        //13	# ??/??
        //14	d/m/yyyy
        //15	d-mmm-yy
        //16	d-mmm
        //17	mmm-yy
        //18	h:mm tt
        //19	h:mm:ss tt
        //20	H:mm
        //21	H:mm:ss
        //22	m/d/yyyy H:mm
        //37	#,##0 ;(#,##0)
        //38	#,##0 ;[Red](#,##0)
        //39	#,##0.00;(#,##0.00)
        //40	#,##0.00;[Red](#,##0.00)
        //45	mm:ss
        //46	[h]:mm:ss
        //47	mmss.0
        //48	##0.0E+0
        //49	@

        #endregion Formats

        General = 0,
        Number = 4,
        Percent = 9,
        Percent2 = 10,
        d_m_yyyy = 14,
        d_mmm_yy = 15,
        h_mm = 20
    }
}