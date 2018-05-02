package com.gambit.novus.adapters

import android.support.v4.app.Fragment
import android.support.v4.app.FragmentManager
import android.support.v4.app.FragmentStatePagerAdapter
import com.gambit.novus.fragments.ContentFragment

class ContentViewPagerAdapter(fragmentManager: FragmentManager) : FragmentStatePagerAdapter(fragmentManager) {

    private val contentList = arrayListOf("a", "b")

    override fun getItem(position: Int): Fragment {
        val content = contentList[position]
        return ContentFragment.create(content)
    }

    override fun getCount(): Int = contentList.size
}