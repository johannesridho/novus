package com.gambit.novus.fragments

import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.gambit.novus.R
import kotlinx.android.synthetic.main.fragment_content.view.*

class ContentFragment : Fragment() {

    companion object {
        val ARG_CONTENT = "ARG_CONTENT"

        fun create(content: String): Fragment {
            val bundle = Bundle()
            bundle.putString(ARG_CONTENT, content)

            val fragment = ContentFragment()
            fragment.arguments = bundle

            return fragment
        }
    }

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val view = inflater.inflate(R.layout.fragment_content, container, false)

        view.textView.text = arguments!!.getString(ARG_CONTENT)

        return view
    }
}