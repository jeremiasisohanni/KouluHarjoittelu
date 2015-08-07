package koulu.myapplication;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import org.w3c.dom.Text;

public class bottomPictureFragment extends Fragment {

    private static TextView topMemeText;
    private static TextView bottomMemeText;


    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.bottom_picture_fragment, container, false);
        topMemeText = (TextView) view.findViewById(R.id.topMemeText);
        bottomMemeText = (TextView) view.findViewById(R.id.bottomMemeText);
        return view;
    }

    public void setMemeText(String top, String bottom) {
        topMemeText.setText(top);
        bottomMemeText.setText(bottom);
    }
}
